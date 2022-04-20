import axios from "axios";
import router from './router'

const instance = axios.create({
    baseURL: `http://localhost:7216/api`,
    withCredentials: true
});

instance.interceptors.response.use(function (response) {
    return response
}, function (error) {
    router.push('/Login')
    console.log(error.response.data)
    if (error.response.status === 401) {
        router.push('/Login')
    }
    return Promise.reject(error)
})

export default instance;