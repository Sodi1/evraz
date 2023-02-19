import httpClient from "../clients/predictHttpClient";

export default class PredictService {
  static async predict(ids, stDate = "2023-02-6", endDate = "2023-02-18") {
    console.log(ids);
    const params = {
      signal_id: ids,
      start_date: stDate,
      end_date: endDate,
    };
    const response = await httpClient()
      .get(`predict`, { params })
      .catch((err) => {
        return err;
      });
    return response;
  }
}
