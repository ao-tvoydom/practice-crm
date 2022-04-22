<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Продукт на складе</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Товар</span>
      </label>
      <Multiselect
          v-model="productInWarehouse.product.productId"
          :searchable="true"
          label="name"
          valueProp="productId"
          :options="products"
          :classes="multiselectClasses"
      >
        <template v-slot:singlelabel="{ value }">
          <div class="multiselect-single-label">
            {{ `${value.name} (id: ${value.productId})` }}
          </div>
        </template>

        <template v-slot:option="{ option }">
          {{ `${option.name} (id: ${option.productId})` }}
        </template>

      </Multiselect>
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Склад</span>
      </label>
      <Multiselect
          v-model="productInWarehouse.warehouse.warehouseId"
          :searchable="true"
          valueProp="warehouseId"
          :options="warehouses"
          :classes="multiselectClasses"
      >
        <template v-slot:singlelabel="{ value }">
          <div class="multiselect-single-label">
            {{ `${value.name} (id: ${value.warehouseId})` }}
          </div>
        </template>

        <template v-slot:option="{ option }">
          {{ `${option.name} (id: ${option.warehouseId})` }}
        </template>

      </Multiselect>
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Количество</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="productInWarehouse.amount">
    </div>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/product_in_storage/${productInWarehouse.productInWarehouseId}`)">Простмотр</button>
  </div>
</template>

<script>
import axios from "@/axios";
import Multiselect from "@vueform/multiselect";
import multiselectClasses from "@/assets/multiselect-classes";


export default {
  name: "EditProductInStorage",
  data() {
    return {
      productInWarehouse: {
        productInWarehouseId: this.$route.params.id,
      },
      products: {},
      warehouses: {},
      multiselectClasses
    }
  },
  methods: {
    save() {
      axios.put(`/ProductInWarehouse/${this.productInWarehouse.productInWarehouseId}`, {
        productInWarehouseId: this.productInWarehouse.productInWarehouseId,
        amount: this.productInWarehouse.amount,
        productId: this.productInWarehouse.product.productId,
        warehouseId: this.productInWarehouse.warehouse.warehouseId
      }).then(() => {
        this.$router.push(`/product_in_storage/${this.productInWarehouse.productInWarehouseId}`)
      })
    }
  },
  created() {
    axios.get('/Product').then((response) => this.products = response.data)
    axios.get('/Warehouse').then((response) => this.warehouses = response.data)
    axios.get(`/ProductInWarehouse/${this.productInWarehouse.productInWarehouseId}`)
        .then((response) => { this.productInWarehouse = response.data })
  },
  components: {
    Multiselect
  }
}
</script>