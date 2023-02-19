import httpClient from "../clients/exhausterHttpClient";

export default class AuthorArticleService {
  static async getMachines(time_machine_offset = null) {
    let params;
    if (time_machine_offset) {
      params = new URLSearchParams([
        ["time_machine_offset", time_machine_offset],
      ]);
    }
    const response = await httpClient()
      .get("sinter_machines", { params })
      .catch((err) => {
        return err;
      });
    return response.data;
  }

  static async getExhauserStatById(id, time_machine_offset = null) {
    if (time_machine_offset) {
      params = new URLSearchParams([
        ["time_machine_offset", time_machine_offset],
      ]);
    }
    if (id) {
      const response = await httpClient()
        .get(`sinter_machines/${id}`)
        .catch((err) => {
          return err;
        });
      return response;
    }
    return null;
  }
}
