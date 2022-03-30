<template>
  <div class="flex items-center mb-2 align-middle">
    <div class="text-3xl mb-2">Отгрузки</div>
    <button class="btn btn-square btn-primary btn-sm ml-2" @click="this.$router.push(`/shipment`)">+</button>
  </div>
  <table class="table table-zebra w-full">

    <thead>
    <tr>
      <th>Товар</th>
      <th>Количество</th>
      <th>Целевой адрес</th>
      <th>Дата начала отгрузки</th>
      <th>Дата окончания отгрузки</th>
      <th>Контактный телефон</th>
      <th>Действия</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="shipment in shipments" :key="shipment.name">
      <td><a class="link link-primary">{{ shipment.product_name }}</a></td>
      <td>{{ shipment.amount }}</td>
      <td>{{ shipment.target_address }}</td>
      <td>{{ shipment.start_date }}</td>
      <td>{{ shipment.end_date }}</td>
      <td>{{ shipment.phone }}</td>
      <td>
        <div class="dropdown dropdown-end">
          <label tabindex="0" class="btn btn-primary m-1 p-2 rounded">...</label>
          <ul tabindex="0" class="dropdown-content menu p-2 shadow bg-base-100 rounded w-52">
            <li><a>Редактировать</a></li>
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
  name: "ShipmentPage",
  data() {
    return {
      shipments: [
        {
          product_name: "Зубная паста",
          amount: 1000,
          target_address: "г. Москва ул. Стахановская д.5 к.1 ",
          start_date: "07.02.2022",
          end_date: "10.02.2022",
          phone: "+7 (495) 434-34-34"
        },
        {
          product_name: "Зубная паста",
          amount: 1000,
          target_address: "г. Москва ул. Стахановская д.5 к.1 ",
          start_date: "07.02.2022",
          end_date: "10.02.2022",
          phone: "+7 (495) 434-34-34"
        },
        {
          product_name: "Зубная паста",
          amount: 1000,
          target_address: "г. Москва ул. Стахановская д.5 к.1 ",
          start_date: "07.02.2022",
          end_date: "10.02.2022",
          phone: "+7 (495) 434-34-34"
        },
        {
          product_name: "Зубная паста",
          amount: 1000,
          target_address: "г. Москва ул. Стахановская д.5 к.1 ",
          start_date: "07.02.2022",
          end_date: "10.02.2022",
          phone: "+7 (495) 434-34-34"
        },
        {
          product_name: "Зубная паста",
          amount: 1000,
          target_address: "г. Москва ул. Стахановская д.5 к.1 ",
          start_date: "07.02.2022",
          end_date: "10.02.2022",
          phone: "+7 (495) 434-34-34"
        }
      ]
    }
  }
}
</script>