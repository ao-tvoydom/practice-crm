<template>
  <table class="w-full">
    <div class="text-3xl">Поставки</div>
    <tr>
      <th class="border-2">Товар</th>
      <th class="border-2">Поставщик</th>
      <th class="border-2">Количество</th>
      <th class="border-2">Дата</th>
    </tr>
    <tr v-for="supply in supplys" :key="supply.product_title">
      <td class="border-2 p-1" >{{ supply.product_title }}</td>
      <td class="border-2 p-1">{{ supply.supplier_name }}</td>
      <td class="border-2 p-1">{{ supply.amount }}</td>
      <td class="border-2 p-1">{{ supply.date }}</td>
    </tr>
  </table>
</template>

<script>
export default {
  name: "SupplysPage",
  data() {
    return {
      supplys: [
        { product_title: "САХАР", supplier_name: "JSC GORODEYA SUGAR REFINERY", amount: 555, date: "12.04.2002" },
        { product_title: "САХАР", supplier_name: "JSC GORODEYA SUGAR REFINERY", amount: 555, date: "12.04.2002" },
        { product_title: "САХАР", supplier_name: "JSC GORODEYA SUGAR REFINERY", amount: 555, date: "12.04.2002" },
        { product_title: "САХАР", supplier_name: "JSC GORODEYA SUGAR REFINERY", amount: 555, date: "12.04.2002" },
        { product_title: "САХАР", supplier_name: "JSC GORODEYA SUGAR REFINERY", amount: 555, date: "12.04.2002" },
        { product_title: "САХАР", supplier_name: "JSC GORODEYA SUGAR REFINERY", amount: 555, date: "12.04.2002" },
        { product_title: "САХАР", supplier_name: "JSC GORODEYA SUGAR REFINERY", amount: 555, date: "12.04.2002" },
        { product_title: "САХАР", supplier_name: "JSC GORODEYA SUGAR REFINERY", amount: 555, date: "12.04.2002" },
      ]
    }
  }
}
</script>

<style scoped>

</style>