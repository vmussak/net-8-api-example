import GetWeather from "./scenarios/get-weather.js";
import { group, sleep } from 'k6';
import { htmlReport } from "https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js";


export function handleSummary(data) {
    return {
        "summary.html": htmlReport(data),
    };
}

export default () => {
    group('Endpoint Get GetWeather - API k6', () => {
        GetWeather();
    });
}