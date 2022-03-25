<template>
  <div class="text-3xl mb-2">Поставки</div>
  <table class="table table-zebra w-full">
    <thead>
      <tr>
        <th>Товар</th>
        <th>Поставщик</th>
        <th>Количество</th>
        <th>Дата</th>
        <th>Действия</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="supply in supplys" :key="supply.product_title">
        <td>{{ supply.product_title }}</td>
        <td>{{ supply.supplier_name }}</td>
        <td>{{ supply.amount }}</td>
        <td>{{ supply.date }}</td>
        <td>
          <div class="dropdown dropdown-end">
            <label tabindex="0" class="btn btn-primary m-1 p-2 rounded">...</label>
            <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
              <li><a>Изменить</a></li>
              <li><a>Удалить</a></li>
            </ul>
          </div>
        </td>
      </tr>
    </tbody>
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