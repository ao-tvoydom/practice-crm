<template>
  <header class="flex mb-4 border-b-2 p-2">
    <div class="text-4xl">ProductCRM</div>
    <div class="text-2xl m-2 cursor-pointer hover:text-primary" v-on:click="currentTab='products'">Товары</div>
    <div class="text-2xl m-2 cursor-pointer hover:text-primary" v-on:click="currentTab='storages'">Склады</div>
    <div class="text-2xl m-2 cursor-pointer hover:text-primary" v-on:click="currentTab='supplys'">Поставки</div>
    <div class="text-2xl m-2 cursor-pointer hover:text-primary" >Отгрузки</div>
  </header>

  <div class="m-2 flex-grow" >
    <ProductsPage v-if=" currentTab==='products' "></ProductsPage>
    <SupplysPage v-if=" currentTab==='supplys' "></SupplysPage>
    <StoragesPage v-if=" currentTab==='storages' "></StoragesPage>
  </div>

  <footer class="fixed bottom-0 footer items-center p-4 bg-neutral text-neutral-content">
    <p>Copyright © 2022 - All right reserved</p>
  </footer>
</template>

<script>
import ProductsPage from "@/components/ProductsPage";
import SupplysPage from "@/components/SupplysPage";
import StoragesPage from "@/components/StoragesPage";


export default {
  name: 'App',
  data() {
    return {
      currentTab: "products"
    }
  },
  components: {
    ProductsPage,
    SupplysPage,
    StoragesPage
  }
}
</script>

<style>

</style>

