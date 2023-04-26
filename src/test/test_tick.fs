\ test_tick.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1748+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

40000 set-origin

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
