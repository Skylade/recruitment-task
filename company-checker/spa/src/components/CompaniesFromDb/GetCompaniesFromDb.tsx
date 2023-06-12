import { Space, Table, Tag } from "antd";
import type { ColumnsType } from "antd/es/table";
import CompanyDataService from "../../services/axios.service";
import { ICompany } from "../../types/company.types";
import { useEffect, useState } from "react";
import { IAccountNumber } from "../../types/accountNumber.types";

const columns: ColumnsType<ICompany> = [
    {
        title: "Name",
        dataIndex: "name",
        key: "name",
        render: (text) => <a>{text}</a>,
    },
    {
        title: "Regon",
        dataIndex: "regon",
        key: "regon",
    },
    {
        title: "Nip",
        dataIndex: "nip",
        key: "nip",
    },
    {
        title: "Restoration Date",
        dataIndex: "restorationDate",
        key: "restorationDate",
    },
    {
        title: "Working Address",
        dataIndex: "workingAddress",
        key: "workingAddress",
    },
    {
        title: "Has Virtual Accounts",
        dataIndex: "hasVirtualAccounts",
        key: "hasVirtualAccounts",
    },
    {
        title: "Status Vat",
        dataIndex: "statusVat",
        key: "statusVat",
    },
    {
        title: "Krs",
        dataIndex: "krs",
        key: "krs",
    },
    {
        title: "Restoration Basis",
        dataIndex: "restorationBasis",
        key: "restorationBasis",
    },
    {
        title: "Registration Denial Basis",
        dataIndex: "registrationDenialBasis",
        key: "registrationDenialBasis",
    },
    {
        title: "Removal Date",
        dataIndex: "removalDate",
        key: "removalDate",
    },
    {
        title: "Registration Legal Date",
        dataIndex: "registrationLegalDate",
        key: "registrationLegalDate",
    },
    {
        title: "Removal Basis",
        dataIndex: "removalBasis",
        key: "removalBasis",
    },
    {
        title: "Pesel",
        dataIndex: "pesel",
        key: "pesel",
    },
    {
        title: "Residence Address",
        dataIndex: "residenceAddress",
        key: "residenceAddress",
    },
    {
        title: "Registration Denial Date",
        dataIndex: "registrationDenialDate",
        key: "registrationDenialDate",
    },
    {
        title: "Request DateTime",
        dataIndex: "requestDateTime",
        key: "requestDateTime",
    },
    {
        title: "Request Id",
        dataIndex: "requestId",
        key: "requestId",
    },
    {
        title: "Account Numbers",
        dataIndex: "accountNumbers",
        render: (accountNumbers) =>
            accountNumbers
                .map((an: IAccountNumber) => an.accountNumber + "\n")
                .join(),
        key: "services",
    },
];

function GetCompaniesFromDb() {
    const [companies, setCompanies] = useState<ICompany[]>();
    const [loaded, setLoaded] = useState<boolean>(false);

    useEffect(() => {
        const fetchData = async () => {
            const responseData =
                await CompanyDataService.getCompaniesFromDb().then(
                    (response) => response.data
                );

            setCompanies(responseData);
            setLoaded(true);
        };

        fetchData();
    }, []);

    return (
        <>
            <div>
                <div className="text-2xl font-bold p-5">Companies from db</div>
                {loaded ? (
                    <Table columns={columns} dataSource={companies} />
                ) : (
                    <div>Loading...</div>
                )}
            </div>
        </>
    );
}

export default GetCompaniesFromDb;
