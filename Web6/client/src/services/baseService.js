import axios from 'axios';

export const API_BASE_URL ='https://localhost:7103/api';

const instance = axios.create({
	baseURL: API_BASE_URL,
    json: true
});


export default instance;