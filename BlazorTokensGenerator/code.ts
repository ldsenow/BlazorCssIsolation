import { TinyColor } from "@ctrl/tinycolor";
import { rgbToHex, rgbToHsv, hslToRgb } from "./tinycolor/src/conversion";
import { inputToRGB } from "./tinycolor/src/format-input";
import genFontSizes from "./ant-design/components/theme/themes/shared/genFontSizes";

// const hsv = rgbToHsv(22,119,255);
// console.log(hsv);

// const rgb = hsvToRgb(hsv.h * 360, hsv.s * 100, hsv.v * 100);
// console.log(rgb);

// import { inputToRGB, rgbToHex, rgbToHsv } from '@ctrl/tinycolor';

const hueStep = 2; // 色相阶梯
const saturationStep = 0.16; // 饱和度阶梯，浅色部分
const saturationStep2 = 0.05; // 饱和度阶梯，深色部分
const brightnessStep1 = 0.05; // 亮度阶梯，浅色部分
const brightnessStep2 = 0.15; // 亮度阶梯，深色部分
const lightColorCount = 5; // 浅色数量，主色上
const darkColorCount = 4; // 深色数量，主色下
// 暗色主题颜色映射关系表
const darkColorMap = [
  { index: 7, opacity: 0.15 },
  { index: 6, opacity: 0.25 },
  { index: 5, opacity: 0.3 },
  { index: 5, opacity: 0.45 },
  { index: 5, opacity: 0.65 },
  { index: 5, opacity: 0.85 },
  { index: 4, opacity: 0.9 },
  { index: 3, opacity: 0.95 },
  { index: 2, opacity: 0.97 },
  { index: 1, opacity: 0.98 },
];

interface HsvObject {
  h: number;
  s: number;
  v: number;
}

interface RgbObject {
  r: number;
  g: number;
  b: number;
}

// Wrapper function ported from TinyColor.prototype.toHsv
// Keep it here because of `hsv.h * 360`
function toHsv({ r, g, b }: RgbObject): HsvObject {
  const hsv = rgbToHsv(r, g, b);
  return { h: hsv.h * 360, s: hsv.s, v: hsv.v };
}

// Wrapper function ported from TinyColor.prototype.toHexString
// Keep it here because of the prefix `#`
function toHex({ r, g, b }: RgbObject): string {
  return `#${rgbToHex(r, g, b, false)}`;
}

// Wrapper function ported from TinyColor.prototype.mix, not treeshakable.
// Amount in range [0, 1]
// Assume color1 & color2 has no alpha, since the following src code did so.
function mix(rgb1: RgbObject, rgb2: RgbObject, amount: number): RgbObject {
  const p = amount / 100;
  const rgb = {
    r: (rgb2.r - rgb1.r) * p + rgb1.r,
    g: (rgb2.g - rgb1.g) * p + rgb1.g,
    b: (rgb2.b - rgb1.b) * p + rgb1.b,
  };
  return rgb;
}

function getHue(hsv: HsvObject, i: number, light?: boolean): number {
  let hue: number;
  // 根据色相不同，色相转向不同
  const a = Math.round(hsv.h);
  if (Math.round(hsv.h) >= 60 && Math.round(hsv.h) <= 240) {
    hue = light
      ? Math.round(hsv.h) - hueStep * i
      : Math.round(hsv.h) + hueStep * i;
  } else {
    hue = light
      ? Math.round(hsv.h) + hueStep * i
      : Math.round(hsv.h) - hueStep * i;
  }
  if (hue < 0) {
    hue += 360;
  } else if (hue >= 360) {
    hue -= 360;
  }
console.log("----------", i, a, hue);

  return hue;
}

function getSaturation(hsv: HsvObject, i: number, light?: boolean): number {
  // grey color don't change saturation
  if (hsv.h === 0 && hsv.s === 0) {
    return hsv.s;
  }
  let saturation: number;
  if (light) {
    saturation = hsv.s - saturationStep * i;
  } else if (i === darkColorCount) {
    saturation = hsv.s + saturationStep;
  } else {
    saturation = hsv.s + saturationStep2 * i;
  }
  // 边界值修正
  if (saturation > 1) {
    saturation = 1;
  }
  // 第一格的 s 限制在 0.06-0.1 之间
  if (light && i === lightColorCount && saturation > 0.1) {
    saturation = 0.1;
  }
  if (saturation < 0.06) {
    saturation = 0.06;
  }
  return Number(saturation.toFixed(2));
}

function getValue(hsv: HsvObject, i: number, light?: boolean): number {
  let value: number;
  if (light) {
    value = hsv.v + brightnessStep1 * i;
  } else {
    value = hsv.v - brightnessStep2 * i;
  }
  if (value > 1) {
    value = 1;
  }
  return Number(value.toFixed(2));
}

interface Opts {
  theme?: "dark" | "default";
  backgroundColor?: string;
}

export default function generate(color: string, opts: Opts = {}): string[] {
  const patterns: string[] = [];
  const pColor = inputToRGB(color);
  for (let i = lightColorCount; i > 0; i -= 1) {
    const hsv = toHsv(pColor);
    const mixedHsv = {
      h: getHue(hsv, i, true),
      s: getSaturation(hsv, i, true),
      v: getValue(hsv, i, true),
    };
    const rgb = inputToRGB(mixedHsv);
    const colorString: string = toHex(rgb);

    console.log(`***${i}***`);
    console.log(pColor);
    console.log(hsv);
    console.log(mixedHsv);
    console.log(rgb);
    console.log(colorString);

    patterns.push(colorString);
  }
  patterns.push(toHex(pColor));
  for (let i = 1; i <= darkColorCount; i += 1) {
    const hsv = toHsv(pColor);
    const colorString: string = toHex(
      inputToRGB({
        h: getHue(hsv, i),
        s: getSaturation(hsv, i),
        v: getValue(hsv, i),
      })
    );
    patterns.push(colorString);
  }

  // dark theme patterns
  if (opts.theme === "dark") {
    return darkColorMap.map(({ index, opacity }) => {
      const darkColorString: string = toHex(
        mix(
          inputToRGB(opts.backgroundColor || "#141414"),
          inputToRGB(patterns[index]),
          opacity * 100
        )
      );
      return darkColorString;
    });
  }
  return patterns;
}

// generate("#FADB14");

// function darken(amount = 10): TinyColor {
//   const hsl = this.toHsl();
//   hsl.l -= amount / 100;
//   hsl.l = clamp01(hsl.l);
//   return new TinyColor(hsl);
// }

const fontSizes = genFontSizes(14);
console.log(fontSizes);
//.toHexString());

export {};
