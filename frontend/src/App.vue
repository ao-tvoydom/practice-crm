<template>
  <div>
    <header class="flex justify-between mb-4 border-b-2 p-2">
      <div class="flex">
        <div class="text-4xl">
          <span>Product</span>
          <span class="text-primary">CRM</span>
        </div>
        <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/">
          Товары
        </router-link>
        <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/warehouses">
          Склады
        </router-link>
        <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/products_in_storage">
          Товары на складах
        </router-link>
        <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/supplies">
          Поставки
        </router-link>
        <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/shipments">
          Отгрузки
        </router-link>
        <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/shipment_contents">
          Отгрузки на скад
        </router-link>
        <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/categories">
          Категории
        </router-link>
      </div>

      <button class="btn btn-primary" @click="logout">Выйти</button>
    </header>

    <div class="m-2 flex-grow">
      <router-view></router-view>
    </div>

    <footer
      class="
        fixed
        bottom-0
        footer
        items-center
        p-4
        bg-neutral
        text-neutral-content
      "
    >
      <p>Copyright © 2022 - All right reserved</p>
    </footer>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "App",
  data() {
    return {
      currentTab: "products",
    };
  },
  methods: {
    logout() {
      axios.post(`/Account/Logout`).then(() => { this.$router.push('/login') })
    }
  }

};
</script>

<style>
</style>

