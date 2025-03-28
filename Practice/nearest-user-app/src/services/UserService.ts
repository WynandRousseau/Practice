import axios from "axios";

const API_URL = "https://jsonplaceholder.typicode.com/users";
const API_URL_Local = "https://localhost:7105/hotel/nearest-user";

export async function fetchUsers() {
    const response = await axios.get(API_URL);
    return response.data;
}

export async function fetchUsers_Local(hotels : any[]) {
    try {
        const response = await axios.post(API_URL_Local,hotels);
        return response.data;
      } catch (error) {
        console.error("Error fetching nearest user data:", error);
      }
    
}
