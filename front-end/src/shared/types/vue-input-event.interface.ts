export interface VueInputEvent extends InputEvent {
    target: VueInputTarget;
}

interface VueInputTarget extends EventTarget {
    value: string;
}