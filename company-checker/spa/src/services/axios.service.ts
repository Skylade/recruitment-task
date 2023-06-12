import { ICompany } from "../types/company.types";
import http from "./config/axios";

class CompanyDataService {
    getCompany(nip: string, date: string) {
        return http.get<ICompany>("/" + nip + "?date=" + date);
    }

    getCompaniesFromDb() {
        return http.get<ICompany[]>("/saved-requests");
    }
}

export default new CompanyDataService();
