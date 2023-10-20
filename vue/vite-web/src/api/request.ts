import axios from 'axios'
import config from "@/api/config";

const instance = axios.create({
  baseURL: config.baseUrl.build,
  timeout: 30000,
});

//get请求
export function get(url:string, params:any) {
  return new Promise((resolve, reject) => {
    instance
      .get(url, {
        params: params,
      })
      .then((response) => {
        resolve(response);
      })
      .catch((err) => {
        reject(err);
      });
  });
}
//post请求
export function post(url:string, data:any) {
  return new Promise((resolve, reject) => {
    instance.post(url, data).then(
      (response) => {
        resolve(response.data);
      },
      (err) => {
        reject(err);
      }
    );
  });
}


  