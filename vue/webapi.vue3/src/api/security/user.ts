import {get,post} from '@/api/request'

export const login=(params:any)=>post('http://localhost:5149/api/User/Login',params)