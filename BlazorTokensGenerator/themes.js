import { writeFileSync, unlinkSync, readdirSync } from "fs";
import { join } from "path";
import { theme } from "antd";

const directory = "./generated";
const seed = theme.defaultSeed;
const defaultTheme = theme.defaultAlgorithm(seed);
const darkTheme = theme.darkAlgorithm(seed, defaultTheme);
const compactTheme = theme.compactAlgorithm(seed, defaultTheme);

emptyFolder();
writeFile("defaultTheme.json", defaultTheme);
writeFile("darkTheme.json", darkTheme);
writeFile("compactTheme.json", compactTheme);

function emptyFolder() {
  const files = readdirSync(directory);

  for (const file of files) {
    unlinkSync(join(directory, file));
  }
}

function writeFile(file, tokens) {
  const data = JSON.stringify(tokens, null, 2);
  writeFileSync(join(directory, file), data);
}
