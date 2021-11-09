export default class Service {
    constructor()
    {
        this.baseUrl = "https://localhost:7071/";
    }

    checkError(response) {
        if (response.status >= 200 && response.status <= 299) {
            return response.json();
        } else {
          throw response;
        }
      }
}