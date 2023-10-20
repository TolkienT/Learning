import {get,post} from '@/api/request'
export const login=(params:any)=>post('/api/User/Login',params)

// import axios from "axios";
// import config from "@/api/config";
// export const login = (params:any) => {
//     return axios.post(`${config.baseUrl.build}/api/User/Login`, params);
//   };