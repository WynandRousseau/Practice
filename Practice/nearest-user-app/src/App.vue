<template>
  <div>
      <h1>Find the Nearest User</h1>
      <NearestUsers />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import NearestUsers from "./components/NearestUsers.vue";

export default defineComponent({
  components: { NearestUsers },
});
</script>


<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
