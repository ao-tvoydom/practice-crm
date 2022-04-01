<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Продукт на складе</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название товара</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.product.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Количество</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.amount">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Вес</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.product.weight">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Высота</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.product.height">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Ширина</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.product.width">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Длинна</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.product.length">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Название склада</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.warehouse.name">
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Адрес склада</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.warehouse.address">
    </div>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/product_in_storage/${productInWarehouse.productInWarehouseId}`)">Простмотр</button>
  </div>
</template>

<script>
import axios from "@/axios";

export default {
  name: "Edit ProductInStorage",
  data() {
    return {
      productInWarehouse: {
        productInWarehouseId: this.$route.params.id
      }
    }
  },
  methods: {
    save() {
      axios.put(`/ProductInWarehouse/${this.productInWarehouse.productInWarehouseId}`, this.productInWarehouse).then(() => {
        this.$router.push(`/product_in_storage/${this.productInWarehouse.productInWarehouseId}`)
      })
    }
  },
  created() {
    axios.get(`/ProductInWarehouse/${this.productInWarehouse.productInWarehouseId}`)
        .then((response) => this.productInWarehouse = response.data)
  }
}
</script>