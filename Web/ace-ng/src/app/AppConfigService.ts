import { Injectable } from '@angular/core';
import { IAppConfig } from './model/IAppConfig';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class AppConfigService {

    settings: IAppConfig;

    constructor(private http: HttpClient) { }

    load() {
        console.log("AppConfigService load()");
        let jsonFile = '';
        jsonFile = `assets/config/config.json`;//TODO hardcoded should be removed later.
        return new Promise<void>((resolve, reject) => {
            this.http.get(jsonFile, { withCredentials: true }).toPromise().then((response: IAppConfig) => {
                console.log("AppConfigService load() response " + response);
                this.settings = response;
                console.log("AppConfigService load() JSON.stringify(AppConfigService.settings) " + JSON.stringify(this.settings));
                resolve();
            }).catch((response: any) => {
                reject(`Could not load file '${jsonFile}': ${JSON.stringify(response)}`);
            });
        });
    }
}
