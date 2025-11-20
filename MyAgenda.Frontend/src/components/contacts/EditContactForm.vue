<script setup>
import { ref, watch } from "vue";
import { api } from "../../api/http"
import { defineProps, defineEmits } from "vue";

const props = defineProps({
  contact: Object,
});

const emit = defineEmits(["close", "updated"]);

const name = ref("");
const email = ref("");
const phone = ref("");

watch(() => props.contact, (c) => {
  if (c) {
    name.value = c.name;
    email.value = c.email;
    phone.value = c.phone;
  }
}, { immediate: true });

const handleSubmit = async () => {
  await api.put(`/contacts/${props.contact.id}`, { name: name.value, email: email.value, phone: phone.value });
  emit("updated");
  emit("close");
};
</script>

<template>
  <div class="modal">
    <h2>Editar Contato</h2>
    <form @submit.prevent="handleSubmit">
      <input v-model="name" placeholder="Nome" required />
      <input v-model="email" placeholder="Email" required />
      <input v-model="phone" placeholder="Telefone" required />
      <button type="submit">Atualizar</button>
      <button type="button" @click="emit('close')">Cancelar</button>
    </form>
  </div>
</template>