export interface VueInputEvent extends Event {
  target: VueInputTarget;
}

interface VueInputTarget extends EventTarget {
  value: string;
}
