<template>
  <div class="card bg-neutral p-4 w-2/5 m-auto ">
    <div class="text-3xl mb-2 text-neutral-content">Отгрузка № {{ shipment.shipmentId }}</div>

    <TextField
        name="Целевой Адрес"
        :vfield="v$.shipment.targetAddress"
        v-model="shipment.targetAddress"
    />
    <DatePicker
        name="Дата начала отгрузки"
        :vfield="v$.shipment.shipmentStartDate"
        v-model="shipment.shipmentStartDate"
    />
    <DatePicker
        name="Дата окончания отгрузки"
        :vfield="v$.shipment.shipmentEndDate"
        v-model="shipment.shipmentEndDate"
    />

    <div class="form-control w-full">
      <label class="label">
        <span class="label-text text-neutral-content">Контактный телефон</span>
      </label>
      <input type="text" class="input input-bordered w-full" v-model="shipment.contactPhone">
    </div>

    <button class="btn btn-primary mt-4" @click="save">Сохранить</button>
    <button class="btn btn-primary mt-4" @click="this.$router.push(`/shipment/${shipment.shipmentId}`)">Простмотр</button>
  </div>

</template>

<script>
import axios from "@/axios";
import validators from "@/validators";
import TextField from "@/controls/TextField";
import DatePicker from "@/controls/DatePicker";
import useVuelidate from "@vuelidate/core";

export default {
  name: "EditShipmentPage",
  setup () {
    return { v$: useVuelidate() }
  },
  data() {
    return {
      shipment: {
        shipmentId: this.$route.params.id
      }
    }
  },
  validations () {
    return {
      shipment: {
        targetAddress: {
          checkLength: validators.checkLength(5, 120),
        },
        shipmentStartDate: {
          checkFullness: validators.checkFullness()
        },
        shipmentEndDate: {
          checkFullness: validators.checkFullness()
        },
      }
    }
  },
  methods: {
    async save() {
      const isFormCorrect = await this.v$.$validate();
      if(!isFormCorrect) return;

      axios.put(`/Shipment/${this.shipment.shipmentId}`, this.shipment).then(() => {
        this.$router.push(`/shipment/${this.shipment.shipmentId}`)
      })
    }
  },
  created() {
    axios.get(`/Shipment/${this.shipment.shipmentId}`).then((response) => this.shipment = response.data)
  },
  components: {
    TextField,
    DatePicker
  }
}
</script>