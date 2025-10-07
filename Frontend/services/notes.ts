const API_URL = "http://localhost:5284/api";

import axios from "axios";
import type { ApiResponse } from "~/models/ApiReponse";
import type { CreateNoteRequest } from "~/models/createNoteRequest";
import type { Note } from "~/models/note";
import type { UpdateNoteRequest } from "~/models/updateNoteRequest";

const api = axios.create({
  baseURL: API_URL,
  withCredentials: true,
  headers: {
    "Content-Type": "application/json",
    Accept: "application/json",
  },
});

export const fetchNotes = async () => {
  try {
    const res = await api.get<ApiResponse<Note[]>>("/note");
    console.log("data: ", res.data.Data);
    return res.data.Data;
  } catch (error) {
    return [];
  }
};

export const fetchNote = async (id: number) => {
  const res = await api.get<Note>(`/note/${id}`);
  return res.data;
};

export const createNote = async (formData: CreateNoteRequest) => {
  const res = await api.post("/note", JSON.stringify(formData));
  return res.data;
};

export const updateNote = async (id: number, formData: UpdateNoteRequest) => {
  const res = await api.patch(`/note/${id}`, JSON.stringify(formData));
  return res.data;
};

export const deleteNote = async (id: number) => {
  const res = await api.delete(`note/${id}`);
  return res.data;
};
