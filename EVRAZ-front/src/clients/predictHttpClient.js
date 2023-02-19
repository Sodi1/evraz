import axios from "axios";

export default () => {
  const baseUrl = "https://evraz-predict.kovalev.team/";

  return axios.create({
    baseURL: baseUrl,
    headers: {
      "Content-Type": "application/x-www-form-urlencoded",
    },
  });
};
