\ test_tick.fs

\ This file is part of Sin Forth.

\ A Forth cross-compiler, written in Forth with Gforth,
\ that compiles Forth programs for the Sinclair ZX Spectrum.

\ By Marcos Cruz (programandala.net), 2020, 2023.

\ Last modified: 20230422T1745+0200.

\ ==============================================================

40000 set-origin
s" test_tick" set-filename

begin-program

require sin_forth/lib/bracket-tick.fs \ `[']`
require sin_forth/lib/constant.fs     \ `constant`
require sin_forth/lib/emit.fs         \ `emit`
require sin_forth/lib/tick.fs         \ `'`
require sin_forth/lib/variable.fs     \ `variable`

'Z' constant zx

'X' variable spectrum

: game ( -- ) zx emit spectrum emit ;

\ XXX REMARK The disassembly of this instructions should show that HL
\ is loaded with the corresponding defitinion address:

  ' zx        h ldp#, \ ld hl,zx_body
['] zx        h ldp#, \ ld hl,zx_body
  ' spectrum  h ldp#, \ ld hl,spectrum_body
['] spectrum  h ldp#, \ ld hl,spectrum_body
  ' game      h ldp#, \ ld hl,game_xt
['] game      h ldp#, \ ld hl,game_xt

4 data-stack

end-program
