import axios from "axios";

export default () => {
  const baseUrl = "https://jwt-api.kovalev.team/";

  return axios.create({
    baseURL: baseUrl,
    headers: {
      "Content-Type": "application/x-www-form-urlencoded",
    },
  });
};
