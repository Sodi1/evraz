import httpClient from "../clients/jwtHttpClient";
export default class AuthorArticleService {
  
  
  static async logIn(login, pass) {
    const postData = new URLSearchParams({
      username: login,
      password: pass,
    });
    const response = await httpClient()
      .post("api/login", postData)
      .catch((err) => {
        return err;
      });
    return response;
  }
}
