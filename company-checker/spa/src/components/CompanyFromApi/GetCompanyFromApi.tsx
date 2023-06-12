import { Button, Form, Input, DatePicker, notification } from "antd";
import CompanyDataService from "../../services/axios.service";
import { useState } from "react";
import { ICompany } from "../../types/company.types";

function GetCompanyFromApi() {
    const [company, setCompany] = useState<ICompany>();
    const [loaded, setLoaded] = useState<boolean>(false);

    const openNotification = (
        notificationMessage: string,
        notificationDescription: string
    ) => {
        notification.open({
            message: notificationMessage,
            description: notificationDescription,
            onClick: () => {
                console.log("Notification Clicked!");
            },
        });
    };

    const onFinish = async (values: any) => {
        console.log("Nip:", values.nip);

        console.log("Date:", values.date.toLocaleString());
        const responseData = await CompanyDataService.getCompany(
            values.nip,
            values.date.toLocaleString()
        ).then((response) => {
            // if (response.status === 200)

            console.log(response);

            openNotification(
                "Success!",
                "The data was successfully fetched from WL Api."
            );

            return response.data;
        });
        console.log(responseData);

        setCompany(responseData);
        setLoaded(true);
    };

    const onFinishFailed = (errorInfo: any) => {
        console.log("Failed:", errorInfo);
    };

    const getAccountNumbers = () => {
        return company?.accountNumbers.map((account) => (
            <li>{account.accountNumber}</li>
        ));
    };

    return (
        <>
            <div>
                <p className="text-2xl font-bold p-5">Companies from Api</p>

                <Form
                    name="basic"
                    labelCol={{ span: 8 }}
                    wrapperCol={{ span: 16 }}
                    style={{ maxWidth: 600 }}
                    initialValues={{ remember: true }}
                    onFinish={onFinish}
                    onFinishFailed={onFinishFailed}
                    autoComplete="off"
                >
                    <Form.Item
                        label="Nip"
                        name="nip"
                        rules={[
                            {
                                required: true,
                                message: "Please input nip!",
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item
                        label="Date"
                        name="date"
                        rules={[
                            {
                                required: true,
                                message: "Please input date!",
                            },
                        ]}
                    >
                        <DatePicker />
                    </Form.Item>

                    <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                        <Button
                            type="primary"
                            htmlType="submit"
                            style={{
                                background: "#2c2c30",
                                borderColor: "#45454b",
                                color: "#ffffff",
                                fontWeight: "bold",
                            }}
                        >
                            Submit
                        </Button>
                    </Form.Item>
                </Form>
            </div>

            <div>
                {loaded ? (
                    <div className=" flex-row text-white bg-slate-800 w-1/4 p-5 rounded-lg">
                        <p className="text-2xl font-bold">Result</p>
                        <br />
                        <p>Nip: {company?.nip}</p>
                        <p>Regon: {company?.regon}</p>
                        <p>Krs: {company?.krs}</p>
                        <p>Name: {company?.name}</p>
                        <p>Pesel: {company?.pesel}</p>
                        <p>
                            Registration Denial Basis:{" "}
                            {company?.registrationDenialBasis}
                        </p>
                        <p>
                            Registration Denial Date:{" "}
                            {company?.registrationDenialBasis}
                        </p>
                        <p>
                            Registration Legal Date:{" "}
                            {company?.registrationLegalDate}
                        </p>
                        <p>Removal Basis: {company?.removalBasis}</p>
                        <p>Removal Date: {company?.removalDate}</p>
                        <p>Representatives: {company?.nip}</p>
                        <p>Request DateTime: {company?.requestDateTime}</p>
                        <p>RequestId: {company?.requestId}</p>
                        <p>Residence Address: {company?.residenceAddress}</p>
                        <p>Restoration Basis: {company?.restorationBasis}</p>
                        <p>Restoration Date: {company?.restorationDate}</p>
                        <p>Status Vat: {company?.statusVat}</p>
                        <p>WorkingAddress: {company?.workingAddress}</p>
                        <p>Account numbers: {getAccountNumbers()}</p>
                    </div>
                ) : (
                    <div></div>
                )}
            </div>
        </>
    );
}

export default GetCompanyFromApi;
