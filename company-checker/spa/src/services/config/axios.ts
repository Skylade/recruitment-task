import axios from "axios";

export default axios.create({
    baseURL: "https://localhost:7238/api/v1/company/",
    headers: {
        "Content-type": "application/json",
    },
});
