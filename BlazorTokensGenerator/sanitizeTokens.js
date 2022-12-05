import { writeFileSync, readFileSync } from "fs";

export default function (fileToProcess) {
  const contents = readFileSync(fileToProcess, { encoding: "utf-8" });

  const replacedContents = contents.replace(
    // replace React.CSSProperties["textDecoration"] to string
    /\"\$ref\": \"#\/definitions\/Property\.TextDecoration%3C\(string%7Cnumber\)%3E\"\,/g,
    '"type": "string",'
  );

  writeFileSync(fileToProcess, replacedContents, { encoding: "utf-8" });
};
