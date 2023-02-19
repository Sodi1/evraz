import httpClient from "../clients/exhausterHttpClient";

export default class AspiratorService {
  static async getAspirator(id, time_machine_offset = null) {
    let params = {};
    if (time_machine_offset) {

      params = new URLSearchParams([
        ["time_machine_offset", time_machine_offset],
      ]);
    }
    if(!id) return null
    const response = await httpClient()
      .get(`aspirators/${id}`, { params })
      .catch((err) => {
        return err;
      });
    return response;
  }
}
