import axios from "axios";
import router from './router'

const instance = axios.create({
    baseURL: `http://localhost:7216/api`,
    withCredentials: true
});

instance.interceptors.response.use(
    response => response,
    function (error) {
        if (error.response.status === 401) {
            router.push('/login');
        }
    return Promise.reject(error)
})

export default instance;