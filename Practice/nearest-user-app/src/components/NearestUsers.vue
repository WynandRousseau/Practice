<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import { fetchUsers,fetchUsers_Local } from "../services/UserService";
import { findNearestUser } from "../utils/distance";
import { hotels } from "@/data/hotels";

interface Hotel {
  name: string;
  lat: number;
  lng: number;
}
interface Hotel_local {
  name: string;
  nearestDistance: number;
  userName: string;
}

export default defineComponent({
    setup() {
        const users = ref([]);
        const nearestUsers = ref<any[]>([]);
        const hotelList: Hotel[] = hotels;
        let localHotels: Hotel_local[] = [];

        onMounted(async () => {
            users.value = await fetchUsers();
            nearestUsers.value = hotelList.map(hotel => ({
                hotel: hotel.name,
                ...findNearestUser(hotel, users.value),
            }));
            // localHotels = await fetchUsers_Local(hotels).map(hotel => ({
            //     name:hotel.name,
            //     userName:hotel.nearestUser.name,
            //     NearestDistance:hotel.nearestUser.nearestDistance,
            //     
            // }));
            console.log(await fetchUsers_Local(hotels));
        });

        return { nearestUsers ,localHotels};
    },
});
</script>

<template>
    <div>
        <h2>Nearest Users</h2>
        <ul>
            <li v-for="item in nearestUsers" :key="item.hotel">
                Hotel {{ item.hotel }} - Nearest User: {{ item.userName }} (Distance: {{ item.minDistance.toFixed(2) }} km)
            </li>
        </ul>
        <h2>Nearest Users from API</h2>
        <ul>
            <li v-for="item in localHotels" :key="item.name">
                Hotel {{ item.name }} - Nearest User: {{ item.userName }} (Distance: {{ item.nearestDistance.toFixed(2) }} km)
            </li>
        </ul>
    </div>
</template>
