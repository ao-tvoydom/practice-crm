<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Добавление отгрузки на склад</div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Товар на складе</span>
      </label>
      <Multiselect
          v-model="shipmentContent.productInWarehouse.productInWarehouseId"
          :searchable="true"
          valueProp="productInWarehouseId"
          :options="productsInWarehouse"
          :classes="multiselectClasses"
      >
        <template v-slot:singlelabel="{ value }">
          <div class="multiselect-single-label">
            <div>{{ `${value.product.name} ( ${value.warehouse.name} )` }}</div>
          </div>
        </template>

        <template v-slot:option="{ option }">
          {{ `${option.product.name} ( ${option.warehouse.name} )` }}
        </template>

      </Multiselect>
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Отгрузка</span>
      </label>
      <Multiselect
          v-model="shipmentContent.shipment.shipmentId"
          :searchable="true"
          valueProp="shipmentId"
          :options="shipments"
          :classes="multiselectClasses"
      >
        <template v-slot:singlelabel="{ value }">
          <div class="multiselect-single-label">
            <div>{{ `${value.targetAddress} ( ${value.shipmentStartDate} )` }}</div>
          </div>
        </template>

        <template v-slot:option="{ option }">
          <div>{{ `${option.targetAddress} ( ${option.shipmentStartDate} )` }}</div>
        </template>
      </Multiselect>
    </div>

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Количество</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="shipmentContent.amount">
    </div>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/shipment_content/${shipmentContent.shipmentId}`)">Простмотр</button>
  </div>
</template>

<script>
import axios from "@/axios";
import Multiselect from "@vueform/multiselect";
import multiselectClasses from "@/assets/multiselect-classes";

export default {
  name: "CreateShipmentContentPage",
  data() {
    return {
      shipmentContent: {
        productInWarehouse: {},
        shipment: {}
      },
      productsInWarehouse: [],
      shipments: [],
      multiselectClasses
    }
  },
  components: {
    Multiselect
  },
  methods: {
    save() {
      axios.post(`/ShipmentContent`, {
        productInWarehouseId: this.shipmentContent.productInWarehouse.productInWarehouseId,
        shipmentId: this.shipmentContent.shipment.shipmentId,
        amount: this.shipmentContent.amount,
      }).then((response) => {
        this.$router.push(`/shipment_content/${response.data.shipmentContentId}`)

      })
    }
  },
  created() {
    axios.get('/ProductInWarehouse').then((response) => this.productsInWarehouse = response.data)
    axios.get('/Shipment').then((response) => this.shipments = response.data)
  }
}
</script>