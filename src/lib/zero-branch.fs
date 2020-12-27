\ lib/zero-branch.fs

\ This file is part of Sin Forth.

\ This file adds `0branch` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012262340.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl.fs

get-order get-current

compiler-definitions

: 0branch \ Compilation: ( dest -- )
          \ Run-time:    ( f -- )
  assembler{
  pop-hl        \ pop hl
  l a ld,       \ ld a,l
  h or,         \ or h   ; HL = zero?
  $0000 z? ?jp, \ jp z,0 ; jump if zero, to an address which
                \        ; will be left by `>mark` and resolved
                \        ; by `>resolve` or `<resolve`.
  } ;

  \ doc{
  \
  \ 0branch  Compilation: ( dest -- )
  \          Run-time:    ( f -- )
  \ "zero-branch"

  \
  \ Compilation: Compile Z80 code to perform the run-time semantics
  \ below. The destination address _dest_ must be resolved by
  \ `>resolve` during the compilation.
  \
  \ Run-time: If  _f_ is false (zero), a Z80 ``jp`` is executed to an
  \ address that was resolved by `>resolve` during the compilation.

  \
  \ // XXX TODO
  \ // See also: `-branch`, `+branch`.
  \
  \ See also: `branch`, `?branch`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Finish and document.
\
\ 2020-12-13: Update the search-order selectors, remove `target{`.
\ Improve documentation.
\
\ 2020-12-26: Fix the stack comment. Update the documentation with
\ `?branch`. Update with `assembler{`.
