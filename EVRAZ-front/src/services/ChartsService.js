import httpClient from "../clients/exhausterHttpClient";

export default class ChartsService {
  static async getCharts(
    ids,
    startTime = "2023-02-13",
    endTime = "2023-02-18"
  ) {
    if (!ids?.length) return null;
    const params = {
      signal_kind_ids: ids,
      start_time: startTime,
      end_time: endTime,
    };
    const response = await httpClient()
      .get(`chart_values`, { params })
      .catch((err) => {
        return err;
      });
    return response.data;
  }
}
