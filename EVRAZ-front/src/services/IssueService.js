import httpClient from "../clients/exhausterHttpClient";

export default class IssueService {

  static async getIssues(state) {
    var status = state === true ? "open" : "closed";

    const params = {
      state: status
    };
    const response = await httpClient()
      .get('/issue_requests',{params})
      .catch((err) => {
        return err;
      });
    return response;
  }
}
