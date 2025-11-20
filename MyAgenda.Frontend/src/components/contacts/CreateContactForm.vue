<script setup>
import { ref } from "vue";
import { api } from "../../api/http"
import { defineEmits } from "vue";

const emit = defineEmits(["close", "created"]);

const name = ref("");
const email = ref("");
const phone = ref("");

const handleSubmit = async () => {
  await api.post("/contacts", { name: name.value, email: email.value, phone: phone.value });
  emit("created");
  emit("close");
};
</script>

<template>
  <div class="modal">
    <h2>Novo Contato</h2>
    <form @submit.prevent="handleSubmit">
      <input v-model="name" placeholder="Nome" required />
      <input v-model="email" placeholder="Email" required />
      <input v-model="phone" placeholder="Telefone" required />
      <button type="submit">Criar</button>
      <button type="button" @click="emit('close')">Cancelar</button>
    </form>
  </div>
</template>