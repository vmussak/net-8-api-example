import http from 'k6/http';
import { sleep } from 'k6';
import { check, fail } from "k6";

export default function () {
    let res = http.get('https://localhost:7051/WeatherForecast')
    
    let durationMsg = 'Falha na execução do cenário de teste weather'

    if(!check(res, {
        'is statuscode 200 - enpoint weather': (r) => r.status === 200
    })){
        fail(durationMsg);
    }
    
    sleep(1);

}