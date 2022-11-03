import axios, {API_BASE_URL} from "./baseService.js";

const apiName = "message";
const fullUrl = `${API_BASE_URL}/${apiName}`;

export async function save(data){
	let result = await axios.post(`${fullUrl}`,data);
	return result;
}
