import "./App.css";
import GetCompaniesFromDb from "./components/CompaniesFromDb/GetCompaniesFromDb";
import GetCompanyFromApi from "./components/CompanyFromApi/GetCompanyFromApi";

function App() {
    return (
        <>
            <div className="p-5">
                <p className="text-4xl font-bold p-5">
                    Welcome to company-checker
                </p>
                <GetCompanyFromApi />
                <GetCompaniesFromDb />
            </div>
        </>
    );
}

export default App;
