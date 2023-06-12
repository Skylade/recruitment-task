import { IAccountNumber } from "./accountNumber.types";
import { IRepresentative } from "./representative.types";

export interface ICompany {
    id: string;
    regon: string;
    nip: string;
    restorationDate: string;
    workingAddress: string;
    hasVirtualAccounts: boolean;
    statusVat: string;
    krs: string;
    restorationBasis: string;
    accountNumbers: IAccountNumber[];
    registrationDenialBasis: string;
    removalDate: string;
    name: string;
    registrationLegalDate: string;
    removalBasis: string;
    pesel: string;
    representatives: IRepresentative[];
    residenceAddress: string;
    registrationDenialDate: string;
    requestDateTime: string;
    requestId: string;
}
