import { rmSync, mkdirSync, writeFileSync, existsSync } from "fs";
import { join } from "path";
import { theme } from "antd";

const directory = "./generated/themes";
const seed = theme.defaultSeed;
const defaultTheme = theme.defaultAlgorithm(seed);
const darkTheme = theme.darkAlgorithm(seed, defaultTheme);
const compactTheme = theme.compactAlgorithm(seed, defaultTheme);

setupFolder();

writeFile("seed.json", seed);
writeFile("defaultTheme.json", defaultTheme);
writeFile("darkTheme.json", darkTheme);
writeFile("compactTheme.json", compactTheme);

function setupFolder() {
  if (existsSync(directory)) {
    rmSync(directory, { recursive: true });
  }

  mkdirSync(directory, { recursive: true });
}

function writeFile(file, tokens) {
  const path = join(directory, file);
  console.log(`********Generating ${path}********`);
  const data = JSON.stringify(tokens, null, 2);
  writeFileSync(path, data);
  console.log(`********Generated ${path}********`);
}
