<template>
  <header class="flex mb-4 border-b-2 p-2">
    <div class="text-4xl">
      <span>Product</span>
      <span class="text-primary">CRM</span>
    </div>
    <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/" >Товары</router-link>
    <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/storages">Склады</router-link>
    <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/supplies">Поставки</router-link>
    <router-link class="text-2xl m-2 cursor-pointer hover:text-primary" to="/shipments">Отгрузки</router-link>
  </header>

  <div class="m-2 flex-grow" >
    <router-view></router-view>
  </div>

  <footer class="fixed bottom-0 footer items-center p-4 bg-neutral text-neutral-content">
    <p>Copyright © 2022 - All right reserved</p>
  </footer>
</template>

<script>

export default {
  name: 'App',
  data() {
    return {
      currentTab: "products"
    }
  }
}
</script>

<style>

</style>

