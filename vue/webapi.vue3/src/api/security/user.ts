import {get,post} from '@/api/request'

export const login=(params:any)=>post('http://124.220.210.116:8081/api/User/Login',params)