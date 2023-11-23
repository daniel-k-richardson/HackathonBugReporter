import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, ReplaySubject } from 'rxjs';
import { take, share, map } from 'rxjs/operators';
import {CompanyLicense, Customer, Transactions} from '../shared/models';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {

  private cache: {[endpoint: string]: Observable<any>} = {};

  constructor(private http: HttpClient) {}

  public invalidateCache() {
    this.cache = {};
  }

  private requestData(endpoint: string) {
    let request = this.cache[endpoint];
    if (!request) {
      request = this.http.get(endpoint).pipe(
        share({
          connector: () => new ReplaySubject(1),
          resetOnError: false,
          resetOnComplete: false,
          resetOnRefCountZero: true,
        })
      );

      this.cache[endpoint] = request;
    }

    return request.pipe(take(1));
  }

  getTransactionData(): Observable<Transactions> {
    // We only want to get the last 7 months of transactions, including this month.
    // Because this endpoint will subtract 1 from the year parameter,
    // we need to add 6 months to today to get the last 7 months.
    const todayPlusSevenMonths = moment().add(6, 'M');
    const year = todayPlusSevenMonths.format('YYYY');
    const month = todayPlusSevenMonths.format('M');
    return this.requestData(`billing/totals/transactions?year=${year}&month=${month}`);
  }

  getActiveCompaniesWithContractType(): Observable<CompanyLicense[]> {
    const filter = `$filter=statuscode eq 'Active' and (contract/contracttype ne 'Demo' and contract/contracttype ne 'Internal') ` +
      `and (contract/enddate gt now() or contract/enddate eq null)`;
    const expand = '$expand=contract($select=contracttype)';
    const select = `$select=id`;
    const endpoint = `companylicenses?${filter}&${expand}&${select}`;
    return this.requestData(endpoint);
  }

  getActivePublicContractTypes(): Observable<any> {
    const filter = `$filter=contracttype ne 'Demo' and IsActive eq true and IsPublic eq true`;
    const select = '$select=contracttype,label';
    const endpoint = `contracttypes?${filter}&${select}`;
    return this.requestData(endpoint);
  }

  getDemoCustomers(lessOrGreater: string): Observable<number> {
    const filter = `$filter=statuscode ne 'SoftDeleted' and statuscode ne 'HardDeleted' and ` +
      `contracts/any(c: c/contracttype eq 'Demo' and c/enddate ${lessOrGreater} now())`;
    const select = '$select=id';
    const endpoint = `customers?${filter}&${select}`;
    return this.requestData(endpoint).pipe(map((res: any[]) => res.length));
  }

  getActiveUsers(): Observable<number> {
    const filter = `$filter=statuscode eq 'Active' and userlicensetype ne 'Support' and companylicense/statuscode eq 'Active'`;
    const select = '$select=id';
    return this.requestData(`userlicenses?${select}&${filter}`).pipe(map((res: any[]) => res.length));
  }

  getActiveUniqueUserLicenses(): Observable<number> {
    return this.requestData(`userlicenses/active-unique?count=true`);
  }

  getBillableCustomersWithContractTypes(): Observable<Customer[]> {
    const filter = `$filter=statuscode ne 'SoftDeleted' and statuscode ne 'HardDeleted' and ` +
      `contracts/any(c:(c/contracttype eq 'Standard' or c/contracttype eq 'Bureau' ` +
      `or c/contracttype eq 'Mini' or c/contracttype eq 'Plus' or c/contracttype eq 'Complete') ` +
      `and c/statuscode eq 'Active' ` +
      `and (c/enddate ge now() or c/enddate eq null) ` +
      `and c/agreementacceptances/any(a: a/timestampofacceptance ne null ` +
      `and a/agreement/agreementtype eq 'Customer'))`;
    const select = '$select=id';
    const expand = `$expand=contracts` +
      `($select=contracttype;$filter=contracttype ne 'Demo' and ` +
      `agreementacceptances/any(a: a/timestampofacceptance ne null and a/agreement/agreementtype eq 'Customer'))`;
    const endpoint = `customers?${filter}&${expand}&${select}`;
    return this.requestData(endpoint);
  }
}
