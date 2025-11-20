<script setup>
import { defineProps, defineEmits } from "vue";
import DeleteContactButton from "./DeleteContactButton.vue";

const props = defineProps({
  contacts: Array,
});

const emit = defineEmits(["edit", "deleted"]);

const handleEdit = (contact) => emit("edit", contact);
const handleDeleted = () => emit("deleted");
</script>

<template>
  <ul>
    <li v-for="contact in contacts" :key="contact.id">
      {{ contact.name }} - {{ contact.email }} - {{ contact.phone }}
      <button @click="handleEdit(contact)">Editar</button>
      <DeleteContactButton :contactId="contact.id" @deleted="handleDeleted"/>
    </li>
  </ul>
</template>