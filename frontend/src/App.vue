<template>
  <div class="h-full">
    <header class="flex mb-4 border-b-2 p-2">
      <div class="text-4xl">ProductCRM</div>
      <div class="text-2xl m-2 cursor-pointer hover:text-blue-500" v-on:click="currentTab='products'">Товары</div>
      <div class="text-2xl m-2 cursor-pointer hover:text-blue-500" >Склады</div>
      <div class="text-2xl m-2 cursor-pointer hover:text-blue-500" v-on:click="currentTab='supplys'">Поставки</div>
      <div class="text-2xl m-2 cursor-pointer hover:text-blue-500" >Отгрузки</div>
    </header>

    <div class="content m-2">
      <ProductsPage v-if=" currentTab==='products' "></ProductsPage>
      <SupplysPage v-if=" currentTab==='supplys' "></SupplysPage>
    </div>

    <footer class="bottom-0 bg-gray-300 p-2 ">© 2022 ProductCRM, все права защищены.</footer>
  </div>
</template>

<script>
import ProductsPage from "@/components/ProductsPage";
import SupplysPage from "@/components/SupplysPage";


export default {
  name: 'App',
  data() {
    return {
      currentTab: "products"
    }
  },
  components: {
    ProductsPage,
    SupplysPage
  }
}
</script>

<style>

</style>

