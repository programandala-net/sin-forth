\ lib/zero-branch.fs

\ This file is part of Sin Forth.

\ This file adds `0branch` to the compiler.

\ By Marcos Cruz (programandala.net), 2020.

\ Last modified: 202012121719.
\ See change log at the end of the file.

\ ==============================================================

require pop-hl.fs

get-order get-current

compiler-definitions

: 0branch \ Compilation: ( -- )
          \ Run-time:    ( f -- )
  target{ pop-hl }    \ pop hl
  compiler{ l a ld, } \ ld a,l \ XXX REMARK `compiler{` is needed
                               \ because `l` is a word of Gforth.
  h or,               \ or h   ; HL = zero?
  $0000 z? ?jp,       \ jp z,0 ; jump if zero, to an address which…
                      \        ; …will be resolved by `>resolve`
  ;

  \ doc{
  \
  \ 0branch  Compilation: ( -- )
  \          Run-time:    ( f -- )
  \ "zero-branch"

  \
  \ Compilation: Compile Z80 code to perform the run-time semantics
  \ below. The destination address must be resolved by `>resolve`
  \ during the compilation.
  \
  \ Run-time: If  _f_ is false (zero), a Z80 ``jp`` is executed to an
  \ address that was resolved by `>resolve` during the compilation.

  \
  \ // XXX TODO
  \ // See also: `branch`, `?branch`, `-branch`, `+branch`.
  \
  \ See also: `branch`.
  \
  \ }doc

set-current set-order

\ ==============================================================
\ Change log {{{1

\ 2020-12-11: Start.
\
\ 2020-12-12: Finish and document.
