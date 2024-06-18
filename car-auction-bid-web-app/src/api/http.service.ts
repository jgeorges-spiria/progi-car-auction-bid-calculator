import { RequestBody } from "./types/request-body.interface";


export class HttpService {

    public static async post(url: string, body: RequestBody = {}): Promise<Response> {
        const response = await fetch(url, 
            {
                method: "POST",
                mode: "cors",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(body)
            }
        );
        return response
    }

}
